import FetchSchoolList from "./FetchSchoolList";
import AddSchool from './AddSchool'
import { useState, useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import '../../Style/SchoolsPage.css';


const Schools = () => {
    const [schoolData, setSchoolData] = useState({ schools: [] });
    const [isLoading, setIsLoading] = useState(false);

    const navigate = useNavigate();

    function navigateToSchool(e, id) {
        e.preventDefault();
        navigate('/govadmin/schools/' + id);
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
        <div className="school-parent">
            <h1>Schools</h1>
            {isLoading ? (
                <div><h3>Loading ...</h3></div>
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
                            <button onClick={(e) => navigateToSchool(e, school.id)}>School page</button>
                        </div>
                    ))}
                </ul>
            )}
            <AddSchool />
        </div>

    );
}	

export default Schools;