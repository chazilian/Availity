import React from 'react'
import Entry from './Entry'

export const Entries = ({entries, onDelete}) => {
  return (
    <table>
        <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>NPI #</th>
            <th>Buisness Address</th>
            <th>Telephone #</th>
            <th>Email Address</th>
            <th></th>
        </tr>
        {entries.map((entry) => (
            <Entry entry={entry} onDelete={onDelete}/>
        ))}
        
    </table>
  )
}
