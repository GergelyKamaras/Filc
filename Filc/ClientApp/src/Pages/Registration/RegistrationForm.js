import FetchSchoolList from "../Schools/FetchSchoolList";
import { useState, useEffect } from 'react';
import bcrypt from 'bcryptjs';

const RegistrationForm = ({ role, form, updateForm, handleSubmit }) => {

    const [schoolData, setSchoolData] = useState({ schools: [] });
    const [isLoading, setIsLoading] = useState(false);
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    
    const updateField = (newValue, field) => {
        
        if (field == "school"){
            updateForm({ ...form, [field]: {"id": newValue} })
        }
        else if (field == "user"){
            updateForm({ ...form, [field]: newValue})}
        else {
            updateForm({ ...form, [field]: newValue })
        }
    }
            
    const createUser = (e) => {
        e.preventDefault();
        const passwordHash = HashPassword(password);
        const user = {
            "email": email,
            "password": passwordHash["hashedPassword"],
            "salt": passwordHash["hashSalt"]
        }
        updateForm({ ...form, ["user"]: user});
        handleSubmit();
    }

    const HashPassword = (password) => {
        let salt = bcrypt.genSaltSync(10);

        const hashedPassword = bcrypt.hashSync(password, salt);
        return {
            "hashedPassword": hashedPassword,
            "hashSalt": salt
            }
    }


    useEffect(() => {
        const fetchData = async () => {
            setIsLoading(true);
            const Schools = await FetchSchoolList();
            setSchoolData({ schools: Schools });
            setIsLoading(false);
        };
        fetchData();
    }, []);


    return (
         <form>
            <div>
                <label htmlFor="email">Email</label>
                <input defaultValue={form?.email ? form.email : ""} onChange={(e) => setEmail(e.target.value)} id="email" type="email" className="form-control" />
            </div>
            <div>
                <label htmlFor="Password">Password</label>
                <input defaultValue={form?.password ? form.password : ""} onChange={(e) => setPassword(e.target.value)} id="Password" type="password" className="form-control" />
            </div>
            {(role === "Student" || role === "Teacher" || role === "SchoolAdmin") &&
                 <div>
                    <div>
                        <label htmlFor="FirstName">First Name</label>
                        <input defaultValue={form?.firstName ? form.firstName : ""} onChange={(e) => updateField(e.target.value, "firstName")} id="FirstName" type="text" className="form-control" />
                    </div>
            
                    <div>
                        <label htmlFor="LastName">Last Name</label>
                        <input defaultValue={form?.lastName ? form.lastName : ""} onChange={(e) => updateField(e.target.value, "lastName")} id="LastName" type="text" className="form-control" />
                    </div>
            
                    <div>
                        <label htmlFor="BirthDate">Date of Birth</label>
                        <input defaultValue={form?.birthDate ? form.birthDate : ""} onChange={(e) => updateField(e.target.value, "birthDate")} id="BirthDate" type="date" className="form-control" />
                    </div>

                    <div>
                        <label htmlFor="Address">Address</label>
                        <input defaultValue={form?.address ? form.address : ""} onChange={(e) => updateField(e.target.value, "address")} id="Address" type="text" className="form-control" />
                    </div>
            
                    <div>
                        <label htmlFor="School">School</label>
                        <select defaultValue={form?.school ? form.school : ""} onChange={(e) => updateField(e.target.value, "school")} id="School" type="text" className="form-control">
                        {isLoading ? (
                            <option>Loading...</option>) :
                            (schoolData.schools.map((school) => (
                            <option value={school.id} className="school" key={school.id}>{school.name}</option>)))}
                        </select>
                    </div>
                 </div>
            }
            {role === "Parent" &&
                <div>
                    <label htmlFor="Children">Add child</label>
                    <select defaultValue={form?.child ? form.child : ""} onChange={(e) => updateField(e.target.value, "child")} id="Child" type="text" className="form-control">
                        <option>These students need to be fetched from the backend</option>
                        <option>Student1</option>
                        <option>Student2</option>
                    </select>
                </div>
            }

            <button type="submit" className="btn btn-primary" onClick={createUser}>Add</button>
        </form>

    )
}
export default RegistrationForm;