const SchoolAdminListFetch = async (id) => {
  const response = await fetch(
    `/api/schooladmins/schools/${id}/admins`, {
          method: 'GET',
          headers: {
              "Authorization": "Bearer" + localStorage.getItem("AccessToken")
          }
  }
  );
  if (!response.ok) {
    return false;
  }
  if (response.json().then((body) => body.length === 0)) {
    return false;
  }
  return response.json();
}

export default SchoolAdminListFetch;