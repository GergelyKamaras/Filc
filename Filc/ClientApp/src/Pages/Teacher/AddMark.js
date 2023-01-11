import UniversalFetch from "../Shared/FetchUniversal";
import { useEffect, useState } from "react";
import jwt from 'jwt-decode';

const AddMark = () => {
    //TODO: Class Selector (School classes) [LATER]
    //TODO: Subject Selector (Teacher Subjects) []
    //TODO: Student Selector (Filtered by class) []
    //TODO: Grade Selector (1-5) []
    //TODO: Description text []
    //TODO: Date (Optional) []
    //TODO: Add Grade button []

    const [teacher, setTeacher] = useState(false);
    const [school, setSchool] = useState(false);

    useEffect(() => {
        const fetchData = async () => {
            const Teacher = await UniversalFetch("get", jwt(localStorage?.AccessToken)["userId"], "");
            const School = await UniversalFetch("get", `schools/${jwt(localStorage?.AccessToken)["schoolId"]}`, "");

            setTeacher(Teacher);
            setSchool(School);
        };
        fetchData();
    }, []);

    const [subject, setSubject] = useState(0);
    const [student, setStudent] = useState(0);
    const [grade, setGrade] = useState(5);
    const [description, setDescription] = useState('');
    const [date, setDate] = useState('');

    console.log(school);
    console.log(teacher);

    function handleSubmit(e) {
        e.preventDefault();

        console.log(subject);
        console.log(student);
        console.log(grade);
        console.log(description);
        console.log(date);
    }

    return (
        <>
            <h2>Give a grade</h2>
            <form>

                <label>Subject:</label>
                <select value={subject} onChange={(e) => setSubject(e.target.value)}>
                    <option value={0}>Please choose one from the list.</option>
                    {teacher ?
                        teacher.subjects.length > 0 ?
                            teacher.subjects.map((subject) =>
                        <option key={subject.id} value={subject.id}>{subject.name}</option>
                            ) : <option value="">There is no subject related to you.</option>
                        : <option>Loading...</option>}
                </select>

                <label>Student:</label>
                <select value={student} onChange={(e) => setStudent(e.target.value)}>
                    <option value={0}>Please choose one from the list.</option>
                    {school ?
                        school.students.map((student) =>
                            <option key={student.id} value={student.id}>{student.firstName} {student.lastName}</option>
                        ) : <option>Loading...</option>}
                </select>

                <label>Grade:</label>
                <select value={grade} onChange={(e) => setGrade(e.target.value)}>
                    <option value={5}>5</option>
                    <option value={4}>4</option>
                    <option value={3}>3</option>
                    <option value={2}>2</option>
                    <option value={1}>1</option>
                </select>

                <label>Description:</label>
                <textarea value={description} onChange={(e) => setDescription(e.target.value)} placeholder="E.g.: Today's test result">
                </textarea>

                <label>Date:</label>
                <input type="date" value={date} onChange={(e) => setDate(e.target.value)} placeholder="éééé-hh-nn" />

                <button type="submit" onClick={(e) => handleSubmit(e)}>Add Grade</button>

            </form>
        </>
    );
}

export default AddMark;