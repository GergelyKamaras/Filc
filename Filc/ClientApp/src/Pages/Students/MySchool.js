import FetchSchoolByIdOnStudentRoute from "./FetchSchoolByIdOnStudentRoute";
import { useEffect, useState } from "react";

const MySchool = () => {
    const [loading, setLoading] = useState(true);
    const [school, setSchool] = useState(false);

    useEffect(
        () => {
            const fetchData = async () => {

                const data = await FetchSchoolByIdOnStudentRoute();

                setSchool(data);
                setLoading(false);
            }
            fetchData();
        }
    );

    return (
        <>
            {loading ? <h3>Loading...</h3>
                : school ? (
                    <div className="school" key={school.id}>
                        <h3>{school.name}</h3>
                        <p><strong>Address:</strong> {school.address}</p>
                        <p><strong>Type: </strong>{school.schoolType}</p>
                        <p><strong>School Admins: </strong></p>
                        {school.schoolAdmin.map((admin) => (
                            <p key={admin.id}> - {admin.firstName} {admin.lastName}</p>
                        ))}
                        <p><strong>Number of students: </strong>{school.students.length}</p>
                        <p><strong>Subjects:</strong></p>
                        {school.subjects.map((subject) => (
                            <p key={subject.id}> - {subject.name}</p>
                        ))}
                        <p><strong>Teachers:</strong> </p>
                        {school.teachers.map((teacher) => (
                            <p key={teacher.id}> - {teacher.firstName} {teacher.LastName}</p>
                        ))}
                    </div>

                ) : (
                    <div>
                        <h3>Data not found</h3>
                        <p>There aren't any schools in the system with that ID.</p>
                    </div>
                )
            }
        </>
    );
}


export default MySchool;