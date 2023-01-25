import { useState, useEffect } from 'react';
import FetchAllStudents from '../Students/FetchAllStudents';
import "../../Style/UserReg/RegisterUser.css"
import {MdSchool} from "react-icons/md" 

const RegisterParent = ({ updateField }) => {
    const [studentData, setStudentData] = useState({ students: [] });
    const [isLoading, setIsLoading] = useState(false);

    useEffect(() => {
        const fetchStudents = async () => {
            setIsLoading(true);
            const Students = await FetchAllStudents();
            setStudentData({ students: Students });
            setIsLoading(false);
        };
        fetchStudents();
    }, []);

    return (
        <div>
                {isLoading ? (
                    <p>Loading students...</p>
                ) : (
                    <div className='register-body'>
                        <div className="icon-div">

                        </div>
                        <div className="title-box">
                            <p> Your Child: </p>
                        </div>
                        <select defaultValue="" onChange={(e) => updateField(e.target.value, "child")} id="Child" type="text" className="role-select">
                        {studentData.students.map((student) => (
                            <option  key={student.id}>{student.firstName} {student.lastName}</option>
                        ))}
                        </select>
                    </div>
                    
                )}
            
        </div>
    )
}
export default RegisterParent;