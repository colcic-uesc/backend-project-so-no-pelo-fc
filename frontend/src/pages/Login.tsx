import { useState } from "react"
import { useNavigate } from "react-router-dom"
import './styles/login.css'

export default function Login() {
  const navigate = useNavigate()
  const [userName, setUserName] = useState('')
  const [password, setPassword] = useState('')
  const [error, setError] = useState<string>('')

  const handleSubmit = async(e: { preventDefault: () => void }) => {
    e.preventDefault()

    try {
      const res = await fetch('http://localhost:5094/api/Auth/login', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ userName, password })
      })

      if(!res.ok)
        throw new Error('Login Failed.')

      const data = await res.json()
      const {token} = data

      localStorage.setItem('token', token)

      console.log('Login successful. Token stored', token)
      navigate('/home')
    } catch (error: unknown) {
      setError('Erro ao fazer login. Tente de novo.')
      console.error('Error: ', error)
    }
  }

  return (
    <div className="login-container">
      <h3 style={{color: 'black'}} className="login-title">Login</h3>
      <form onSubmit={handleSubmit} className="login-form">
        <div className="form-group">
          <label style={{color: 'black'}} htmlFor="userName">Usuario:</label>
          <input
            id="userName"
            type="text"
            value={userName}
            onChange={(e) => setUserName(e.target.value)}
            required
            className="input-field"
          />
        </div>
        <div className="form-group">
          <label style={{color: 'black'}} htmlFor="password">Senha:</label>
          <input
            id="password"
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
            className="input-field"
          />
        </div>
        <button type="submit" className="submit-button">Login</button>
      </form>
      {error && <p className="error-message">{error}</p>}
    </div>
  );
}
