import FetchAddSchool from './FetchAddSchool'
import { useRef } from 'react'
import '../../Style/AddSchool.css';

function AddSchool() {
    const nameInputRef = useRef();
    const addressInputRef = useRef();
    const schoolTypeInputRef = useRef();

    const addSchoolToDb = (e) => {
        e.preventDefault();

        const name = nameInputRef.current.value;
        const address = addressInputRef.current.value;
        const schoolType = schoolTypeInputRef.current.value;

        var schoolData = {
            Name: name,
            address: address,
            schoolType: schoolType,
            schoolAdmin: [],
            students: [],
            subjects: [],
            lessons: [],
            teachers: [],
            classes: []
        };

        FetchAddSchool(schoolData);
    }

    return (
        <div className="add-new-school" style={{ display: 'grid', float: 'right' }}>
            <h3>Register a new school</h3>
            <div className="col-md-12">
                <form>
                    <div className="form-group">
                        <label htmlFor="name">School Name</label>
                        <input ref={nameInputRef} id="name" type="text" className="form-control" />
                    </div>
                    <div className="form-group">
                        <label htmlFor="address">Address</label>
                        <input ref={addressInputRef} id="address" type="text" className="form-control" />
                    </div>
                    <div className="form-group">
                        <label htmlFor="schoolType">School type:</label>
                        <input ref={schoolTypeInputRef} id="schoolType" type="text" className="form-control" />
                    </div>

                    <button type="submit" className="btn btn-primary"
                        onClick={addSchoolToDb}>Register School</button>

                </form>
            </div>
        </div>
    )
}

export default AddSchool;