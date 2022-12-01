import SchoolListFetch from "../Controllers/SchoolListFetch";

const Schools = () => {
  const SchoolList = SchoolListFetch();

  return (
    <>
      <h1>List of Schools</h1>
      {SchoolList.length > 0 ? SchoolList.forEach(school => {
        <p>{school}</p>
      }) : <p>There isn't any schools to list.</p>}
    </>
  );
}

export default Schools;