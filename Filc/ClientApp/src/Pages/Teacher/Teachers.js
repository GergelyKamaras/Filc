import UniversalFetch from "../Shared/FetchUniversal";
import { useEffect, useState } from "react";
import jwt from 'jwt-decode';

const Teachers = () => {
    const [loading, setLoading] = useState(true);
    const [teachers, setTeachers] = useState(false);

    useEffect(
        () => {
            const fetchData = async () => {

                const data = await UniversalFetch("get", `teachers/${jwt(localStorage.AccessToken)["schoolId"]}`);
                console.log(data);

                setTeachers(data);
                setLoading(false);
            }
            fetchData();
        }, []
    );

    return (
        <>
            {loading ? <h3>Loading...</h3>
                : teachers ? (
                    teachers.map((teacher) => (
                        <div key={teacher.id}>
                            <h3>{teacher.firstName} {teacher.lastName}</h3>
                            <p><strong>Birthdate:</strong>{teacher.birthDate}</p>
                            <p><strong>Address:</strong>{teacher.address}</p>
                        </div>
                        )   
                    )
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

export default Teachers;