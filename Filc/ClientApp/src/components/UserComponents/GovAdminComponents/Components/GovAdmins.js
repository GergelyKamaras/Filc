import GovAdminListFetch from "../Controllers/GovAdminListFetch";

const GovAdmins = () => {
  const GovAdminList = JSON.stringify(GovAdminListFetch);

  return (
    <>
      <h1>List of Government Admins</h1>
      {GovAdminList?.forEach(admin => {
        <p>{admin}</p>
      })}
    </>
  );
}

export default GovAdmins;