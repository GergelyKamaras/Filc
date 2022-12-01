const SchoolListFetch = async () => {
  const response = await fetch(
    'https://localhost:7014/api/governmentadmins/', {
    method: 'GET'
  }
  );
  return response.json();
}

export default SchoolListFetch;