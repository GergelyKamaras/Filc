import FetchSchoolAdminList from "./FetchSchoolAdminList";
import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";

const SchoolAdmins = () => {
  const params = useParams();
  const [loading, setLoading] = useState(true);
  const [schoolAdmins, setSchoolAdmins] = useState(false);

  useEffect(
    () => {
      const fetchData = async () => {

        const data = await FetchSchoolAdminList(params.schoolid);

        setSchoolAdmins(data);
        setLoading(false);
      }
      fetchData();
    }
  );

  return (
    <>
      {loading ? <h1>Loading Data</h1> 
        : schoolAdmins ? (
          <div>
          <h1>SchoolAdmin Data</h1>
          {
            schoolAdmins.map((admin) => (
              <div key={admin.id}>
                <h3>{admin.firstName} {admin.lastName}</h3>
                <p><strong>Birthdate:</strong>{admin.birthdate}</p>
                <p><strong>Address:</strong>{admin.address}</p>
              </div>
              )
            )
          }
          </div>
      ) : (
            <div>
              <h1>Data not found</h1>
              <p>This school either doesn't have a School Admin or doesn't exist.</p>
            </div>
      )
      }
    </>
  );
}

export default SchoolAdmins;