import SchoolAdminListFetch from "../Controllers/SchoolAdminListFetch";

const SchoolAdmins = () => {
  const SchoolAdminList = SchoolAdminListFetch();

  return (
    <>
      <h1>List of School Admins</h1>
      {SchoolAdminList.length > 0 ? GovAdminList.forEach(admin => {
        <p>{admin}</p>
      }) : <p>There isn't a school with this id or the school doesn't have an administrator.</p>}
    </>
  );
}

export default SchoolAdmins;