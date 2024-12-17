import React, { useState, useEffect } from 'react';
import Modal from '../components/StudentModal'; // Import the modal component
import { apiCall } from '../utils/apiCall'; // Assuming you have the apiCall method

const StudentTable: React.FC = () => {
  const [students, setStudents] = useState<Student[]>([]);
  const [newStudent, setNewStudent] = useState<Student>({
    id: 0,
    registration: '',
    name: '',
    email: '',
    course: '',
    bio: '',
    user: { username: '', rules: '' },
  });
  const [isModalOpen, setIsModalOpen] = useState(false);

  useEffect(() => {
    const fetchStudents = async () => {
      const data = await apiCall<Student[]>('http://localhost:5094/api/Students');
      setStudents(data);
    };
    fetchStudents();
  }, []);

  const handleAddStudent = async () => {
    const addedStudent = await apiCall<Student>('http://localhost:5094/api/Students', {
      method: 'POST',
      body: JSON.stringify(newStudent),
    });
    setStudents([...students, addedStudent]);
    setIsModalOpen(false); 
  };

  const handleEditStudent = async (id: number) => {
    const updatedStudent = await apiCall<Student>(`http://localhost:5094/api/Students/${id}`, {
      method: 'PUT',
      body: JSON.stringify(newStudent),
    });
    setStudents(students.map(student => (student.id === id ? updatedStudent : student)));
    setIsModalOpen(false); 
  };

  const handleDeleteStudent = async (id: number) => {
    await apiCall(`http://localhost:5094/api/Students/${id}`, { method: 'DELETE' });
    setStudents(students.filter(student => student.id !== id));
  };

  const handleModalOpen = (student?: Student) => {
    if (student) {
      setNewStudent(student);
    } else {
      setNewStudent({
        id: 0,
        registration: '',
        name: '',
        email: '',
        course: '',
        bio: '',
        user: { username: '', rules: '' },
      });
    }
    setIsModalOpen(true);
  };

  return (
    <div>
      {/* Students Table */}
      <table>
        <thead>
          <tr>
            <th>Matricula</th>
            <th>Nome</th>
            <th>Email</th>
            <th>Curso</th>
            <th>Acoes</th>
          </tr>
        </thead>
        <tbody>
          {students.map(student => (
            <tr key={student.id}>
              <td>{student.registration}</td>
              <td>{student.name}</td>
              <td>{student.email}</td>
              <td>{student.course}</td>
              <td>
                <button onClick={() => handleModalOpen(student)}>Editar</button>
                <button style={{color: 'red'}} onClick={() => handleDeleteStudent(student.id)}>Deletar</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <button style={{color: 'green', marginBottom: '1rem'}} onClick={() => handleModalOpen()}>Criar Estudante</button>
      {/* Modal for Add/Edit */}
      <Modal isOpen={isModalOpen} onClose={() => setIsModalOpen(false)}>
        <h4 style={{color: 'black'}}>{newStudent.id ? 'Editar Estudante' : 'Criar Estudante'}</h4>
        <input
          type="text"
          placeholder="Matricula"
          value={newStudent.registration}
          onChange={e => setNewStudent({ ...newStudent, registration: e.target.value })}
          required
        />
        <input
          type="text"
          placeholder="Nome"
          value={newStudent.name}
          onChange={e => setNewStudent({ ...newStudent, name: e.target.value })}
          required
        />
        <input
          type="email"
          placeholder="Email"
          value={newStudent.email}
          onChange={e => setNewStudent({ ...newStudent, email: e.target.value })}
          required
        />
        <input
          type="text"
          placeholder="Curso"
          value={newStudent.course}
          onChange={e => setNewStudent({ ...newStudent, course: e.target.value })}
          required
        />
        <button onClick={newStudent.id ? () => handleEditStudent(newStudent.id) : handleAddStudent}>
          {newStudent.id ? 'Salvar' : 'Criar'}
        </button>
      </Modal>
    </div>
  );
};

export default StudentTable;
