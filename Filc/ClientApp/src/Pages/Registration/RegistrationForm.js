import FetchSchoolList from "../Schools/FetchSchoolList";
import RegisterParent  from "./RegisterParent";
import { useState, useEffect } from 'react';


const RegistrationForm = ({ role, form, updateForm, handleSubmit }) => {

    const [schoolData, setSchoolData] = useState({ schools: [] });
    const [isLoading, setIsLoading] = useState(false);

    
    const updateField = (newValue, field) => {
        
        if (field === "email"){
            updateForm({ ...form, "user": {"email": newValue}})
        }
        else if (field === "password"){
            updateForm({ ...form, "user": {...form["user"] ,"password": newValue}});
        }
        else {
            updateForm({ ...form, [field]: newValue })
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
                <input defaultValue={form?.email ? form.email : ""} onChange={(e) => updateField(e.target.value, "email")} id="email" type="email" className="form-control" />
            </div>
            <div>
                <label htmlFor="Password">Password</label>
                <input defaultValue={form?.password ? form.password : ""} onChange={(e) => updateField(e.target.value, "password")} id="Password" type="password" className="form-control" />
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
                        <label htmlFor="SchoolId">School</label>
                        <select defaultValue={form?.school ? form.school : ""} onChange={(e) => updateField(e.target.value, "SchoolId")} id="SchoolId" type="text" className="form-control">
                        {isLoading ? (
                            <option>Loading...</option>) :
                            (schoolData.schools.map((school) => (
                            <option value={school.id} className="school" key={school.id}>{school.name}</option>)))}
                        </select>
                    </div>
                 </div>
            }
            {role === "Parent" &&
                <RegisterParent updateField={updateField} />
            }

            <button type="submit" className="btn btn-primary" onClick={handleSubmit}>Add</button>
        </form>

    )
}
export default RegistrationForm;