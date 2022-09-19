import React from 'react'
import { FaTimes } from 'react-icons/fa'


const Entry = ({entry, onDelete}) => {
  return (
    <tr>
        <td>{entry.firstName}</td>
        <td>{entry.lastName}</td>
        <td>{entry.npiNumber}</td>
        <td>{entry.buisnessAddress}</td>
        <td>{entry.telephoneNumber}</td>
        <td>{entry.emailAddress}</td>
        <td><FaTimes style={{color:'red', cursor: 'pointer'}} onClick={() => onDelete(entry.id)}/></td>
    </tr>
    
  )
}

export default Entry