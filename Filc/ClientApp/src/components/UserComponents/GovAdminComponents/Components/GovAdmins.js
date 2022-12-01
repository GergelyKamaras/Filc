import GovAdminListFetch from "../Controllers/GovAdminListFetch";

const GovAdmins = () => {
  const GovAdminList = GovAdminListFetch();

  return (
    <>
      <h1>List of Government Admins</h1>
      {GovAdminList.length > 0 ? GovAdminList.forEach(admin => {
        <p>{admin}</p>
      }) : <p>There isn't any admins to list.</p>}
    </>
  );
}

export default GovAdmins;