import SchoolFetchById from "../Controllers/SchoolFetchById";
import { useParams } from 'react-router-dom';
import { useEffect, useState } from "react";

const School = () => {
  let params = useParams();
  const [loading, setLoading] = useState(true);
  const [school, setSchool] = useState(false);

  useEffect(() => {
    const dataFetch = async () => {

      const data = await SchoolFetchById(params.id);

      setSchool(data);
      setLoading(false);
    }
    dataFetch();
  }, []);

  return (
    <>
      {loading ? <h1>Loading Data...</h1>
        : school ? (
          <div>
            <h1>{school.name} Data</h1>
            <p>{school.address}</p>
            <p>{school.schoolType}</p>
          </div>
        ) : (
            <div>
              <h1>Data not found</h1>
              <p>We haven't found anything under this id</p>
            </div>
          )
      }
    </>
  );
}

export default School;