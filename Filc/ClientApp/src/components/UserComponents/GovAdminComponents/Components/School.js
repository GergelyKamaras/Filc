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
      {loading ? <h3>Loading...</h3>
        : school ? (
            <div className="school" key={school.id}>
                <h3>{school.name}</h3>
                <p><strong>Address:</strong> {school.address}</p>
                <p><strong>Type: </strong>{school.schoolType}</p>
                <p><strong>School Admins: </strong></p>
                    {school.schoolAdmin.map((admin) => (
                        <p admin-id={admin.id}> - {admin.firstName} {admin.lastName}</p>
                    ))}
                <p><strong>Number of students: </strong>{school.students.length}</p>
                <p><strong>Students:</strong></p>
                    {school.students.map((student) => (
                        <p student-id={student.id}> - {student.firstName} {student.lastName}</p>
                    ))}
                <p><strong>Subjects:</strong></p>
                      {school.subjects.map((subject) => (
                          <p subject-id={subject.id}> - {subject.name}</p>
                      ))}
                <p><strong>Lessons:</strong></p>
                <p><strong>Teachers:</strong> </p>
                      {school.teachers.map((teacher) => (
                          <p teacher-id={teacher.id}> - {teacher.firstName} {teacher.LastName}</p>
                      ))}
                <p><strong>Classes: </strong></p>
                      {school.classes.map((schoolClass) => (
                          <p schoolClass-id={schoolClass.id}> - {schoolClass.name}</p>
                      ))}
            </div>
          
        ) : (
            <div>
              <h3>Data not found</h3>
              <p>There aren't any schools in the system with that ID.</p>
            </div>
          )
      }
    </>
  );
}

export default School;