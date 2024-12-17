import './App.css'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import Login from './pages/Login'
import Layout from './components/Layout'
import Home from './pages/Home'

function App() {
  return (
    <Router>
      <Layout>
        <Routes>
          <Route path='/login' element={<Login />}/>
          <Route path='/home' element={<Home />}></Route>
        </Routes>
      </Layout>
    </Router>
  )
}

export default App
