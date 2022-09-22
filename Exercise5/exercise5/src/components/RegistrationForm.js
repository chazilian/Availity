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
    const address = '^[0-9a-zA-Z-,# ]+$'
    const numbers = '^[0-9]+$'
    const numbersNPI = '^[0-9]{10}'

    const [presentFNameWarning, setPresentFNameWarning] = useState(false)
    const [presentLNameWarning, setPresentLNameWarning] = useState(false)
    const [presentNPINumberWarning, setPresentNPINumberWarning] = useState(false)
    const [presentBAddressWarning, setPresentBAddressWarning] = useState(false)
    const [presentTelephoneWarning, setPresentTelephoneWarning] = useState(false)
    const [presentEmailWarning, setPresentEmailWarning] = useState(false)

    const onSubmit = (e) => {
        e.preventDefault()

        if(!firstName || !lastName || !npiNumber || !buisnessAddress || !telephoneNumber || !emailAddress){
            alert('Missing required fields')
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

    const firstNameListener = (value) => {
        setFirstName(value)
        setPresentFNameWarning(!value)
    }

    const lastNameListener = (value) => {
        setLastName(value)
        setPresentLNameWarning(!value)
    }

    const npiListener = (value) => {
        setNPINumber(value)
        setPresentNPINumberWarning(!value)
    }

    const buisnessAddressListener = (value) => {
        setBuisnessAddress(value)
        setPresentBAddressWarning(!value)
    }

    const telephoneListener = (value) => {
        setTelephoneNumber(value)
        setPresentTelephoneWarning(!value)
    }

    const emailAddressListener = (value) => {
        setEmailAddress(value)
        setPresentEmailWarning(!value)
    }

  return (
    <form className='add-form' onSubmit={onSubmit}> 
        <div className='form-control'>
            <label className={presentFNameWarning ? 'red' : 'black'}>First Name</label>
            <input 
            type='text' 
            placeholder='Steve' 
            value={firstName} 
            pattern={letters}
            title='Only alphabetical letters'
            min = '1'
            max = '50'
            onChange={(e) => firstNameListener(e.target.value)}/>
        </div>
        <div className='form-control'>
        <label className={presentLNameWarning ? 'red' : 'black'}>Last Name</label>
            <input 
            type='text' 
            placeholder='Jobs' 
            value={lastName} 
            pattern={letters}
            title='Only alphabetical letters' 
            min = '1'
            max = '50'
            onChange={(e) => lastNameListener(e.target.value)}/>
        </div>
        <div className='form-control'>
            <label className={presentNPINumberWarning ? 'red' : 'black'}>NPI #</label>
            <input 
            type='text'
            title='Only 10 digit numbers' 
            placeholder='1234567890' 
            value={npiNumber} 
            pattern={numbersNPI}
            onChange={(e) => npiListener(e.target.value)}/>
        </div>
        <div className='form-control'>
            <label className={presentBAddressWarning ? 'red' : 'black'}>Buisness Address</label>
            <input 
            type='text' 
            placeholder='123 fake street'
            title='Only alphanumeric characters'  
            value={buisnessAddress} 
            pattern={address}
            min = '5'
            max = '100'  
            onChange={(e) => buisnessAddressListener(e.target.value)}/>
        </div>
        <div className='form-control'>
            <label className={presentTelephoneWarning ? 'red' : 'black'}>Telephone #</label>
            <input 
            type='tel' 
            placeholder='3053053055'
            title='Only numbers'  
            value={telephoneNumber} 
            pattern={numbers} 
            min = '9'
            max = '25' 
            onChange={(e) => telephoneListener(e.target.value)}/>
        </div>
        <div className='form-control'>
            <label className={presentEmailWarning ? 'red' : 'black'}>Email Address</label>
            <input 
            type='email' 
            placeholder='steve.jobs@apple.com'
            value={emailAddress}
            min = '5'
            max = '75'  
            onChange={(e) => emailAddressListener(e.target.value)}/>
        </div>
        <div className='center'>
        <input type='submit' value='Save Entry' className='btn btn-block' />
        </div>
    </form>
  )
}

export default RegistrationForm