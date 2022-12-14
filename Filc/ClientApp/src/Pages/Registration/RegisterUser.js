﻿import { useState } from 'react'
import RegisterUserFetch from './FetchRegisterUser'
import RegistrationForm from './RegistrationForm';
import bcrypt from 'bcryptjs';

const RegisterUser = () => {
    
    const [role, updateRole] = useState("");
    const [form, updateForm] = useState({});

    function handleChange(event) {
        updateRole(event.target.value);
    }
    function handleSubmit(e) {
        e.preventDefault();

        const hashes = HashPassword(form["user"]["password"]);
        form["user"]["PasswordHash"] = hashes["hashedPassword"];
        form["user"]["salt"] = hashes["hashSalt"];
        form["user"]["role"] = role;
        alert("Launching fetch for: " + role);
        console.log(form)
        RegisterUserFetch(form, role);
        // possibly add creatorRole as a parameter in the future for authorization purposes

        //.then((response) => navigate/responseID
        //fetch could later return registered user object,
        //Id can be taken from that to navigate to user view page
    }

    function HashPassword (password) {
        let salt = bcrypt.genSaltSync(10);

        const hashedPassword = bcrypt.hashSync(password, salt);
        return {
            "hashedPassword": hashedPassword,
            "hashSalt": salt
            }
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