import SchoolAdminListFetch from "../Controllers/SchoolAdminListFetch";
import { useParams } from "react-router-dom";

const SchoolAdmins = () => {
  const params = useParams();
  const SchoolAdminList = SchoolAdminListFetch(params.schoolid);

  return (
    <>
      <h1>List of School Admins</h1>
      {SchoolAdminList.length > 0 ? SchoolAdminList.forEach(admin => {
        <p>{admin}</p>
      }) : <p>There isn't a school with this id or the school doesn't have an administrator.</p>}
    </>
  );
}

export default SchoolAdmins;