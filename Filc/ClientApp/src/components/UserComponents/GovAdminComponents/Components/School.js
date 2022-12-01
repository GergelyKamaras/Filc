import SchoolFetchById from "../Controllers/SchoolFetchById";
import { useParams } from 'react-router-dom';

const SchoolAdmin = () => {
  let params = useParams();
  const RequestedSchool = SchoolFetchById(params.id);

  return (
    <>
      <h1>School Data</h1>
      {RequestedSchool.length > 0 ? <p>{RequestedSchool}</p> : <p>We didn't find a School with this id.</p>}
    </>
  );
}

export default SchoolAdmin;