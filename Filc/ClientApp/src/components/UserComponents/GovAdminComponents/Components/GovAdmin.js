import GovAdminListFetchById from "../Controllers/GovAdminListFetchById";

const GovAdmin = (id) => {
  const RequestedAdmin = GovAdminListFetchById(id); 

  return (
    <>
      <h1>Admin Data</h1>
      {RequestedAdmin.length > 0 ? <p>{RequestedAdmin}</p> : <p>We didn't find a Government Admin with this is.</p> }
    </>
  );
}

export default GovAdmin;