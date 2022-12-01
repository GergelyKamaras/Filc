const GovAdminListFetch = async (id) => {
  const response = await fetch(
    `https://localhost:7014/api/schooladmins/schools/${id}/admins`, {
    method: 'GET'
  }
  );
  if (!response.ok) {
    return JSON.stringify({});
  }
  return response.json();
}

export default GovAdminListFetch;