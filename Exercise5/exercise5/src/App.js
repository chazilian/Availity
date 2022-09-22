import logo from './logo.svg';
import './App.css';
import RegistrationForm from './components/RegistrationForm';
import { Entries } from './components/Entries';
import {useState} from 'react'
import { FaTasks } from 'react-icons/fa';


const App = () => {
  //form to input stuff
  //validation for that form
  //table to hold a submitted form
  //a way to delete a submitted form
  const[entries, setEntries] = useState([])

  const addEntry = (entry) => {
    const id = Math.floor(Math.random() * 10000) + 1

    const newEntry = {id, ...entry}
    setEntries([...entries, newEntry])
  }

  const deleteEntry = (id) => {
    setEntries(entries.filter((entry)=> entry.id != id))
  }


  return (
    <div className="App">
      <h1>Availity Healthcare Provider Registration Form</h1>
      <RegistrationForm addEntry={addEntry}/>
      <Entries onDelete={deleteEntry} entries={entries}/>
    </div>
  );
}

export default App;
