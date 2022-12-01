import SchoolAdminFetchById from "../Controllers/SchoolAdminFetchById";
import { useParams, useNavigate } from 'react-router-dom';
import { useEffect, useState } from "react";

const SchoolAdmin = () => {
    let { id } = useParams();
    const [loading, setLoading] = useState(true);
    const [schoolAdmin, setSchoolAdmin] = useState(false);

    const navigate = useNavigate();

    function navigateToSchool(e, id) {
        e.preventDefault();
        navigate('/govadmin/schools/' + id);
    }

    useEffect(() => {
    const fetchData = async () => {
        const data = await SchoolAdminFetchById(id);

        setSchoolAdmin(data);
        console.log(data);
        setLoading(false);
    }
    fetchData();
    }, []);

  return (
    <>
      {loading ? <h3>Loading...</h3>
          : schoolAdmin ? (
              <div>
                  <h1>SchoolAdmin Data</h1>
                    <div className="school-admin" key={schoolAdmin.id}>
                        <h3>{schoolAdmin.firstName} {schoolAdmin.lastName}</h3>
                        <p><strong>Birthdate:</strong> {schoolAdmin.birthdate}</p>
                        <p><strong>Address: </strong>{schoolAdmin.address}</p>
                        <p><strong>Admin of: {schoolAdmin.school.name}</strong></p>
                          <button onClick={(e) => navigateToSchool(e, schoolAdmin.school.id)}>School page</button>
                    </div>
              </div>
          ) : (
              <div>
                <h1>Data not Found</h1>
                <p>This SchoolAdmin was not found.</p>
              </div>
            )
      }
    </>
  );
}

export default SchoolAdmin;