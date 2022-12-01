import SchoolAdminFetchById from "../Controllers/SchoolAdminFetchById";
import { useParams } from 'react-router-dom';

const SchoolAdmin = () => {
  let params = useParams();
  const RequestedAdmin = SchoolAdminFetchById(params.id);

  return (
    <>
      <h1>School Admin Data</h1>
      {RequestedAdmin.length > 0 ? <p>{RequestedAdmin}</p> : <p>We didn't find a School Admin with this id.</p>}
    </>
  );
}

export default SchoolAdmin;