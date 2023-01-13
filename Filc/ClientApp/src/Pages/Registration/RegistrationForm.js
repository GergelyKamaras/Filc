import FetchSchoolList from "../Schools/FetchSchoolList";
import UniversalFetch from "../Shared/FetchUniversal"
import RegisterParent  from "./RegisterParent";
import { useState, useEffect } from 'react';
import {IoMailSharp} from "react-icons/io5"
import {MdPassword, MdSchool} from "react-icons/md" 
import {GrDocumentUser} from "react-icons/gr"
import "../../Style/UserReg/RegisterUser.css"

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
            const Schools = await UniversalFetch("get", "schools", "");
            setSchoolData({ schools: Schools });
            setIsLoading(false);
        };
        fetchData();
        updateField(1,"SchoolId")
    }, []);


    return (
         <form>
            <div className="register-body">
                <div className="icon-div">
                    <IoMailSharp className="form-icon"/>
                </div>
                <div className="title-box">
                     <p> Email: </p>
                </div>
                <input defaultValue={form?.email ? form.email : ""} onChange={(e) => updateField(e.target.value, "email")} id="email" type="email" className="input" />
            </div>
            <div className="register-body">
            <div className="icon-div">
                    <MdPassword className="form-icon"/>
                </div>
                <div className="title-box">
                     <p> Password: </p>
                </div>
                <input defaultValue={form?.password ? form.password : ""} onChange={(e) => updateField(e.target.value, "password")} id="Password" type="password" className="input" />
            </div>
            {(role === "Student" || role === "Teacher" || role === "SchoolAdmin") &&
                 <div>
                    <div className="register-body">
                        <div className="icon-div">
                        <GrDocumentUser className="form-icon"/>
                        </div>
                        <div className="title-box">
                            <p> First Name: </p>
                        </div>
                        <input defaultValue={form?.firstName ? form.firstName : ""} onChange={(e) => updateField(e.target.value, "firstName")} id="FirstName" type="text" className="input" />
                    </div>
            
                    <div className="register-body">
                        <div className="icon-div">
                        </div>
                        <div className="title-box">
                            <p> Last Name: </p>
                        </div>
                        <input defaultValue={form?.lastName ? form.lastName : ""} onChange={(e) => updateField(e.target.value, "lastName")} id="LastName" type="text" className="input" />
                    </div>
            
                    <div className="register-body">
                        <div className="icon-div">
                        </div>
                        <div className="title-box">
                            <p> Birth Date: </p>
                        </div>
                        <input defaultValue={form?.birthDate ? form.birthDate : ""} onChange={(e) => updateField(e.target.value, "birthDate")} id="BirthDate" type="date" className="role-select input" />
                    </div>

                    <div className="register-body">
                        <div className="icon-div">
                        </div>
                        <div className="title-box">
                            <p> Address: </p>
                        </div>
                        <input defaultValue={form?.address ? form.address : ""} onChange={(e) => updateField(e.target.value, "address")} id="Address" type="text" className="input" />
                    </div>
            
                    <div className="register-body">
                        <div className="icon-div">
                        <MdSchool className="form-icon"/>
                        </div>
                        <div className="title-box">
                            <p> School: </p>
                        </div>
                        <select defaultValue={form?.school ? form.school : ""} onChange={(e) => updateField(e.target.value, "SchoolId")} id="Id" type="text" className="role-select">
                        {isLoading ? (
                            <option>Loading...</option>) :
                            (schoolData.schools.map((school) => (
                            <option value={school.id} key={school.id}>{school.name}</option>)))}
                        </select>
                    </div>
                 </div>
            }
            {role === "Parent" &&
                <RegisterParent updateField={updateField} />
            }

            <button type="submit" className="submit-button" onClick={handleSubmit}>Add</button>
        </form>

    )
}
export default RegistrationForm;