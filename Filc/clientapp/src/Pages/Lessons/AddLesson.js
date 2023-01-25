import { useState, useEffect } from 'react'
import "../../Style/UserReg/RegisterUser.css"
import {FaSchool} from "react-icons/fa"
import { BsBookFill} from "react-icons/bs"
import UniversalFetch from '../Shared/FetchUniversal'
import jwt from 'jwt-decode';

function AddLesson() {
    
    const [form, updateForm] = useState({});
    const [lesson, setLesson] = useState({});
    const [school, setSchool] = useState({});
    const [isLoading, setIsLoading] = useState(false);
    let schoolId = jwt(localStorage.AccessToken)["schoolId"];

    const updateField = (newValue, field) => {
        updateForm({ ...form, [field]: newValue })
    }

    useEffect(() => {
        const fetchSchool = async () => {
            setIsLoading(true);
            setSchool(await UniversalFetch("get", `schools/${schoolId}`));
            await setIsLoading(false);
            await console.log(school);
        };
        fetchSchool();
    }, []);

    async function addLessonToDb(e){
        e.preventDefault();
        var lessonData = {
            Name: form["Name"],
            SchoolId: await jwt(localStorage?.AccessToken)["schoolId"],
            SubjectId: form["SubjectId"]
        };

        var result = await UniversalFetch("post", "lessons", lessonData);
        if (result.status === "Success") {
            alert("You have registered the lesson.");
        } else {
            alert("Something went wrong.")
        }
    }

    return (
        <div className='register-form'>
            <div className='register-form-header'>
                <p>Register a new lesson</p>
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
                        <input  onChange={(e) => updateField(e.target.value, "Name")} id="Name" type="text" className="input" />
                    </div>
                    <div className='register-body'>
                        <div className="icon-div">
                            <BsBookFill className='form-icon'/>
                        </div>
                        <div className="title-box">
                            <p>Subject:</p>
                        </div>
                        <select defaultValue="" onChange={(e) => setLesson(e.target.value)} className="select">
                            {isLoading ? (
                                <option>Loading subjects...</option>
                                ) : ((school.Subjects ?
                                    school.Subjects.length > 0 ?
                                        school.Subjects.map((subject) =>
                                    <option key={subject.id} value={subject.id}>{subject.name}</option>
                                        ) : <option>There aren't any subjects registered in your school.</option>
                                    : <option>Something went wrong.</option>))}
                        </select>
                    </div>
                    <button type="submit" className="submit-button"
                        onClick={addLessonToDb}>Add new Lesson</button>
                </form>
            </div>
        </div>
    )
}

export default AddLesson;