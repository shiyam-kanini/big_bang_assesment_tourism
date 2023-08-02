import { useEffect } from 'react';
import './App.css';
import {employeeLogin, employeeRegister, userRegister, userLogin, logout} from './services/authServices/authServices'
import axios from 'axios';
import Comp from './components/component';
function App() {
  
  const fetchFestivals = async() => {
    try{
      const response = await axios.get('https://www.googleapis.com/drive/v3/about')
      console.log(response)
    }
    catch(error){
      console.log(error)
    }
  }
  return (
    <div className="App">
      <Comp></Comp>
    </div>
  );
}

export default App;
