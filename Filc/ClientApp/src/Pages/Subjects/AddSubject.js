import { useState } from 'react'
import "../../Style/UserReg/RegisterUser.css"
import {FaSchool} from "react-icons/fa"
import { ImLocation2 } from "react-icons/im"
import {TbListDetails} from "react-icons/tb"
import UniversalFetch from '../Shared/FetchUniversal'
import jwt from 'jwt-decode';

function AddSubject() {
    
    const [form, updateForm] = useState({});

    const updateField = (newValue, field) => {
        updateForm({ ...form, [field]: newValue })
    }

    async function addSubjectToDb(e){
        e.preventDefault();
        var subjectData = {
            Title: form["Title"],
            SchoolId: await jwt(localStorage?.AccessToken)["schoolId"]
        };

        var result = await UniversalFetch("post", "subjects", subjectData);
        if (result.status === "Success") {
            alert("You have registered the subject.");
        } else {
            alert("Something went wrong.")
        }
    }

    return (
        <div className="register-form">
            <div className='register-form-header'>
                <p>Register a new subject</p>
            </div>
            <div className='register-form-body'>
                <form>
                    <div className="register-body">
                        <div className="icon-div">
                            <FaSchool className='form-icon'/>
                        </div>
                        <div className="title-box">
                            <p> Name: </p>
                        </div>
                        <input  onChange={(e) => updateField(e.target.value, "Title")} id="Title" type="text" className="input" />
                    </div>
                    

                    <button type="submit" className="submit-button"
                        onClick={addSubjectToDb}>Add new Subject</button>

                </form>
            </div>
        </div>
    )
}

export default AddSubject;