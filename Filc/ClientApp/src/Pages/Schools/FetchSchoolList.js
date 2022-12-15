import Header from "../Shared/Header";

const SchoolListFetch = async () => {
  const response = await fetch(
    'https://localhost:7014/api/governmentadmins/schools', {
          method: 'GET',
          headers: {
              "Authorization": "Bearer " + localStorage.getItem("AccessToken")
          }
  }
  );
  return response.json();
}

export default SchoolListFetch;