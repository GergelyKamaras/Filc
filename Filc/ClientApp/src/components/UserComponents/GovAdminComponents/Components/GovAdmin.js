import GovAdminListFetchById from "../Controllers/GovAdminListFetchById";
import { useParams } from 'react-router-dom';

const GovAdmin = () => {
  let params = useParams();
  const RequestedAdmin = GovAdminListFetchById(params.id); 

  return (
    <>
      <h1>Admin Data</h1>
      {RequestedAdmin.length > 0 ? <p>{RequestedAdmin}</p> : <p>We didn't find a Government Admin with this is.</p> }
    </>
  );
}

export default GovAdmin;