const SchoolListFetch = async () => {
  const response = await fetch(
    'https://localhost:7014/api/governmentadmins/schools', {
    method: 'GET'
  }
  );
  return response.json();
}

export default SchoolListFetch;