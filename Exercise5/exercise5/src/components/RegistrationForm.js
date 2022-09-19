import React from 'react'
import {useState} from 'react'

const RegistrationForm = ({addEntry}) => {
    const [firstName, setFirstName] = useState('')
    const [lastName, setLastName] = useState('')
    const [npiNumber, setNPINumber] = useState('')
    const [buisnessAddress, setBuisnessAddress] = useState('')
    const [telephoneNumber, setTelephoneNumber] = useState('')
    const [emailAddress, setEmailAddress] = useState('')

    const letters = '[A-Za-z]+$'
    const alphaNumeric = '^[0-9a-zA-Z ]+$'
    const address = '^[0-9a-zA-Z-, ]+$'
    const numbers = '^[0-9]+$'
    const numbersNPI = '^[0-9]{10}'



    const onSubmit = (e) => {
        e.preventDefault()

        if(!firstName){
            alert('Please add a correct first name')
            return
        }

        if(!lastName){
            alert('Please add a correct last name')
            return
        }

        if(!npiNumber){
            alert('Please add a correct NPI number')
            return
        }

        if(!buisnessAddress){
            alert('Please add a correct buisness address')
            return
        }

        if(!telephoneNumber){
            alert('Please add a correct telephone number')
            return
        }

        if(!emailAddress){
            alert('Please add a email address')
            return
        }

        addEntry({firstName, lastName, npiNumber, buisnessAddress, telephoneNumber, emailAddress})

        setFirstName('')
        setLastName('')
        setNPINumber('')
        setBuisnessAddress('')
        setTelephoneNumber('')
        setEmailAddress('')
    }



  return (
    <form className='add-form' onSubmit={onSubmit}> 
        <div className='form-control'>
            <label>First Name</label>
            <input 
            type='text' 
            placeholder='Steve' 
            value={firstName} 
            pattern={letters}
            min = '1'
            max = '50'
            onChange={(e) => setFirstName(e.target.value)}/>
        </div>
        <div className='form-control'>
        <label>Last Name</label>
            <input 
            type='text' 
            placeholder='Jobs' 
            value={lastName} 
            pattern={letters} 
            min = '1'
            max = '50'
            onChange={(e) => setLastName(e.target.value)}/>
        </div>
        <div className='form-control'>
            <label>NPI #</label>
            <input 
            type='text' 
            placeholder='1234567890' 
            value={npiNumber} 
            pattern={numbersNPI}
            onChange={(e) => setNPINumber(e.target.value)}/>
        </div>
        <div className='form-control'>
            <label>Buisness Address</label>
            <input 
            type='text' 
            placeholder='123 fake street' 
            value={buisnessAddress} 
            pattern={address}
            min = '5'
            max = '100'  
            onChange={(e) => setBuisnessAddress(e.target.value)}/>
        </div>
        <div className='form-control'>
            <label>Telephone #</label>
            <input 
            type='tel' 
            placeholder='3053053055' 
            value={telephoneNumber} 
            pattern={numbers} 
            min = '9'
            max = '25' 
            onChange={(e) => setTelephoneNumber(e.target.value)}/>
        </div>
        <div className='form-control'>
            <label>Email Address</label>
            <input 
            type='email' 
            placeholder='steve.jobs@apple.com' 
            value={emailAddress}
            min = '5'
            max = '75'  
            onChange={(e) => setEmailAddress(e.target.value)}/>
        </div>
        <input type='submit' value='Save Entry' className='btn btn-block' />
    </form>
  )
}

export default RegistrationForm