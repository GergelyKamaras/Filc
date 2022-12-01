import SchoolAdminFetchById from "../Controllers/SchoolAdminFetchById";
import { useParams } from 'react-router-dom';
import { useEffect, useState } from "react";

const SchoolAdmin = () => {
  let params = useParams();
  const [loading, setLoading] = useState(true);
  const [schoolAdmin, setSchoolAdmin] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      const data = await SchoolAdminFetchById(params.id);

      setSchoolAdmin(data);
      setLoading(false);
    }
    fetchData();
  }, []);

  return (
    <>
      {
        loading ? <h1>Data Loading</h1>
          : schoolAdmin ? (
            <div>
              <h1>SchoolAdmin Data</h1>
              <p><strong>First Name:</strong>{schoolAdmin.firstName}</p>
              <p><strong>Last Name:</strong>{schoolAdmin.lastName}</p>
              <p><strong>Birthdate:</strong>{schoolAdmin.birthdate}</p>
              <p><strong>Address:</strong>{schoolAdmin.address}</p>
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