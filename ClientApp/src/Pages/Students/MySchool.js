import FetchSchoolByIdOnStudentRoute from "./FetchSchoolByIdOnStudentRoute";
import { useEffect, useState } from "react";
import Loading from "../Shared/Loader";
import "../../Style/SchoolPage/SchoolPage.css"

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
        },[]);

    return (
        <>
            {loading ? <Loading/>
                : school ? (
                    <div className="school" key={school.id}>
                        <div className="school-header">
                            <p> {school.name}</p>
                        </div>
                        <div className="school-body">
                            <div className="school-address">
                                <p className="address-title"> Address </p>
                                <a href="https://www.google.com/maps/place/Very+Rd,+Machias,+NY+14101,+USA/@42.4023945,-78.5262785,17z/data=!3m1!4b1!4m5!3m4!1s0x89d25bac90436571:0x5a9f8df8f8567c0e!8m2!3d42.4023906!4d-78.5240898" className="address"> {school.address} </a>
                            </div>
                            <div className="school-type">
                                <p className="type-title"> Qualification of school education </p>
                                <p className="type"> {school.schoolType} </p>
                            </div>
                            <div className="school-administrator">
                                <p className="administrator-title"> School administrator </p>
                                {school.schoolAdmin.map((admin) => (
                                <p className="administrator" key={admin.id}>  {admin.firstName} {admin.lastName} </p>
                                ))}
                            </div>
                            <div className="school-students">
                                <p className="students-title"> Total students </p>
                                <p className="students"> {school.students.length} </p>
                            </div>
                        </div>
                            <div className="school-footer">
                        </div>
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