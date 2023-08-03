import { useEffect } from 'react';
import './App.css';
import {getEmployeeProfile, getUserProfile, updateEmployeeProfile, updateUserProfile} from './services/profileServices/profileService'

function App() {
  
  const fetchData = async() => {
    try{
      const response = await updateUserProfile("UID96479", {
        "userFirstName": "string",
        "userLastName": "string",
        "userImageUrl": "string",
        "userEmail": "string",
        "countryCode": "string",
        "userPhone": "string",
        "userState": "string",
        "password": "string"
      });
      console.log(response)
    }
    catch(error){
      console.log(error)
    }
  }
  
  return (
    <div className="App">
      <button onClick={fetchData}>get</button>
    </div>
  );
}

export default App;
