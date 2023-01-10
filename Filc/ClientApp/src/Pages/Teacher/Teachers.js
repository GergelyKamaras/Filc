import UniversalFetch from "../Shared/FetchUniversal";
import { useEffect, useState } from "react";
import jwt from 'jwt-decode';

const Teachers = () => {
    const [loading, setLoading] = useState(true);
    const [teachers, setTeachers] = useState(false);

    useEffect(
        () => {
            const fetchData = async () => {

                const data = await UniversalFetch("get", `schools/${jwt(localStorage.AccessToken)["schoolId"]}`);

                setTeachers(data);
                setLoading(false);
            }
            fetchData();
        }
    );

    return (
        <>
            {loading ? <h3>Loading...</h3>
                : teachers ? (
                    <div className="school" key={teachers.id}>
                        <h3>{teachers.name}</h3>
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

export default Teachers;