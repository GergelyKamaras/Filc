import UniversalFetch from "../Shared/FetchUniversal";
import { useEffect, useState } from "react";
import jwt from 'jwt-decode';
import "../../Style/Teacher/AddMark.css"
import {MdSubject, MdDescription} from "react-icons/md";
import {BsFillFilePersonFill, BsFillCalendarDateFill} from "react-icons/bs";
import {GiUpgrade} from "react-icons/gi";

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
        <div className="add-mark-container">
            <div className="add-mark-header">
                <p>Give a grade</p>
            </div>
            <div className="add-mark-form-body">
                <form>
                <div className="add-mark-body">
                    <div className="icon-div">
                        <MdSubject className="form-icon"/>
                    </div>
                    <div className="title-box">
                        <p> Subject: </p>
                    </div>
                    <select className="select" value={subject} onChange={(e) => setSubject(e.target.value)}>
                        <option value={0}>Please choose one from the list.</option>
                        {teacher.subjects ?
                            teacher.subjects.length > 0 ?
                                teacher.subjects.map((subject) =>
                            <option key={subject.id} value={subject.id}>{subject.name}</option>
                                ) : <option value="">There is no subject related to you.</option>
                            : <option>Loading...</option>}
                    </select>
                </div>
                <div className="add-mark-body">
                    <div className="icon-div">
                        <BsFillFilePersonFill className="form-icon"/>
                    </div>
                    <div className="title-box">
                        <p> Student: </p>
                    </div>
                    <select className="select" value={student} onChange={(e) => setStudent(e.target.value)}>
                        <option value={0}>Please choose one from the list.</option>
                        {school ?
                            school.students.map((student) =>
                                <option key={student.id} value={student.id}>{student.firstName} {student.lastName}</option>
                            ) : <option>Loading...</option>}
                    </select>
                </div>
                <div className="add-mark-body">
                    <div className="icon-div">
                        <GiUpgrade className="form-icon"/>
                    </div>
                    <div className="title-box">
                        <p> Grade: </p>
                    </div>
                    <select className="select" value={grade} onChange={(e) => setGrade(e.target.value)}>
                        <option value={5}>5</option>
                        <option value={4}>4</option>
                        <option value={3}>3</option>
                        <option value={2}>2</option>
                        <option value={1}>1</option>
                    </select>
                </div>
                <div className="add-mark-body">
                    <div className="icon-div">
                        <MdDescription className="form-icon"/>
                    </div>
                    <div className="title-box">
                        <p> Description: </p>
                    </div>
                    <input className="input" value={description} onChange={(e) => setDescription(e.target.value)} placeholder="E.g.: Today's test result">
                    </input>

                </div>
                <div className="add-mark-body">
                    <div className="icon-div">
                        <BsFillCalendarDateFill className="form-icon"/>
                    </div>
                    <div className="title-box">
                        <p> Date: </p>
                    </div>
                        <input className="input" type="date" value={date} onChange={(e) => setDate(e.target.value)} placeholder="éééé-hh-nn" />
                </div>
                    <button className="submit-button" type="submit" onClick={(e) => handleSubmit(e)}>Add Grade</button>
                </form>
            </div>
        </div>
    );
}

export default AddMark;