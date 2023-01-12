import { useState, useEffect } from 'react';
import jwt from 'jwt-decode';
import UniversalFetch from '../Shared/FetchUniversal';

// THIS WILL BE FOR ASSIGNING A LESSON/SUBJECT TO A TEACHER, WIP

export function LinkTeacher(){
    const [lesson, setLesson] = useState("");
    const [school, setSchool] = useState("");
    const [isLoading, setIsLoading] = useState(false);
    let schoolId = jwt(localStorage.AccessToken)["schoolId"];

    useEffect(() => {
        const fetchSchool = async () => {
            setIsLoading(true);
            setSchool(await UniversalFetch("get", `schools/${schoolId}`));
            setIsLoading(false);
            await console.log(school);
        };
        fetchSchool();
    }, []);


    return (
        <div>
            {isLoading ? (
                <p>Loading lessons...</p>
            ) : (
            <div>
                <form>
                    <label>Please select the lesson you would like to assign:</label>
                        <select defaultValue="" onChange={(e) => setLesson(e.target.value)}>
                            {school.Lessons ?
                                    school.Lessons.length > 0 ?
                                        school.Lessons.map((lesson) =>
                                    <option key={lesson.id} value={lesson.id}>{lesson.name}</option>
                                        ) : <option>There aren't any lessons registered in your school.</option>
                                    : <option>Loading...</option>}
                        </select>
                </form>
            </div>)}                  
        </div>
    );
}