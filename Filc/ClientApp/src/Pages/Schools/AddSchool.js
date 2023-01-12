import FetchAddSchool from './FetchAddSchool'
import { useState } from 'react'
import "../../Style/UserReg/RegisterUser.css"
import {FaSchool} from "react-icons/fa"
import { ImLocation2 } from "react-icons/im"
import {TbListDetails} from "react-icons/tb"

function AddSchool() {
    
    const [form, updateForm] = useState({});

    const updateField = (newValue, field) => {
    
        updateForm({ ...form, [field]: newValue })
    
    }   

    const addSchoolToDb = (e) => {
        e.preventDefault();
        var schoolData = {
            name: form["name"],
            address: form["address"],
            schoolType: form["schoolType"]
        };

        FetchAddSchool(schoolData);
    }

    return (
        <div className="register-form">
            <div className='register-form-header'>
                <p>Register a new school</p>
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
                        <input  onChange={(e) => updateField(e.target.value, "name")} id="name" type="text" className="input" />
                    </div>
                    <div className="register-body">
                        <div className="icon-div">
                            <ImLocation2 className='form-icon'/>
                        </div>
                        <div className="title-box">
                            <p> Address: </p>
                        </div>
                        <input onChange={(e) => updateField(e.target.value, "address")} id="address" type="text" className="input" />
                    </div>
                    <div className="register-body">
                        <div className="icon-div">
                            <TbListDetails className="form-icon"/>
                        </div>
                        <div className="title-box">
                            <p> SchoolType: </p>
                        </div>
                        <input onChange={(e) => updateField(e.target.value, "schoolType")} id="schoolType" type="text" className="input" />
                    </div>

                    <button type="submit" className="submit-button"
                        onClick={addSchoolToDb}>Register School</button>

                </form>
            </div>
        </div>
    )
}

export default AddSchool;