import SchoolListFetch from "../Controllers/SchoolListFetch";
import { useState, useEffect } from 'react'

const Schools = () => {
    const [schoolData, setSchoolData] = useState({ schools: [] });
    const [isLoading, setIsLoading] = useState(false);

    useEffect(() => {
        const fetchData = async () => {
            setIsLoading(true);
            const Schools = await SchoolListFetch();
            setSchoolData({ schools: Schools });
            setIsLoading(false);
        };
        fetchData();
    }, []);

    return (
        <div>
            <h1>Schools</h1>
            {isLoading ? (
                <div>Loading ...</div>
            ) : (
                <ul>
                    {schoolData.schools.map((school) => (
                        <div className="school" key={school.id}>
                            <h3>{school.name}</h3>
                            <p><strong>Address:</strong> {school.address}</p>
                            <p><strong>Type: </strong>{school.schoolType}</p>
                            <p><strong>School Admins: </strong></p>
                                {school.schoolAdmin.map((admin) => (
                                <p key={admin.id}> - {admin.firstName} {admin.lastName}</p>
                            ))}
                            <p><strong>Number of students: </strong>{school.students.length}</p>
                            <p>Subjects:</p>
                            <p>Lessons:</p>
                            <p>Teachers: </p>
                            <p>Classes: </p>
                        </div>
                    ))}
                </ul>
            )}
        </div>

    );
}	

export default Schools;