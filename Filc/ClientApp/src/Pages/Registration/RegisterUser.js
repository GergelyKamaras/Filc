import { useState } from 'react'
import RegisterUserFetch from './FetchRegisterUser'
import RegistrationForm from './RegistrationForm';


const RegisterUser = () => {
    
    const [role, updateRole] = useState("");
    const [form, updateForm] = useState({ user: {} });

    function handleChange(event) {
        updateRole(event.target.value);
    }
    function handleSubmit(event) {
        alert("Launching fetch for: " + role);
        event.preventDefault();



        

       

        RegisterUserFetch(form, role);
        // possibly add creatorRole as a parameter in the future for authorization purposes

        //.then((response) => navigate/responseID
        //fetch could later return registered user object,
        //Id can be taken from that to navigate to user view page
    }

   

    return (
        <div className="register-form">
            <h1>Register new user</h1>

            <select onChange={handleChange}>
                <option value="Government">Government Admin</option>
                <option value="SchoolAdmin">School Admin</option>
                <option value="Teacher">Teacher</option>
                <option value="Student">Student</option>
                <option value="Parent">Parent</option>
            </select>

            <RegistrationForm role={role} updateForm={updateForm} form={form} handleSubmit={handleSubmit} />
                   
        </div>

    );
}

export default RegisterUser;