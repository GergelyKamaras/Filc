import { useState, useEffect } from 'react';
import FetchAllStudents from '../Students/FetchAllStudents';

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
                    <div>
                        <label htmlFor="Child">Add child</label>
                        <select defaultValue="" onChange={(e) => updateField(e.target.value, "child")} id="Child" type="text" className="form-control">
                        {studentData.students.map((student) => (
                            <option className="student" key={student.id}>{student.firstName} {student.lastName}</option>
                        ))}
                        </select>
                    </div>
                    
                )}
            
        </div>
    )
}
export default RegisterParent;