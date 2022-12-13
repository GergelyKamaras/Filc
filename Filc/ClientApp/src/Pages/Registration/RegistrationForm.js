const RegistrationForm = ({ role, form, updateForm, handleSubmit }) => {
    const update = (newValue, field) => {
        updateForm({...form, [field]: newValue})
    }

    return (
         <form>
            <div>
                <label htmlFor="Email">Email</label>
                <input defaultValue={form.email} value={form.email} onChange={(e)=>update(e.target.value, "email")} id="Email" type="email" className="form-control" />
            </div>
            <div>
                <label htmlFor="Password">Password</label>
                <input  id="Password" type="password" className="form-control" />
            </div>
            {(role === "Student" || role === "Teacher" || role === "SchoolAdmin") &&
                 <div>
                    <div>
                        <label htmlFor="FirstName">First Name</label>
                        <input id="FirstName" type="text" className="form-control" />
                    </div>
            
                    <div>
                        <label htmlFor="LastName">Last Name</label>
                        <input id="LastName" type="text" className="form-control" />
                    </div>
            
                    <div>
                        <label htmlFor="BirthDate">Date of Birth</label>
                        <input id="BirthDate" type="date" className="form-control" />
                    </div>

                    <div>
                        <label htmlFor="Address">Address</label>
                        <input id="Address" type="text" className="form-control" />
                    </div>
            
                    <div>
                        <label htmlFor="School">School</label>
                        <select id="School" type="text" className="form-control">
                            <option>These schools need to be fetched from the backend</option>
                            <option>School2</option>
                            <option>School3</option>
                        </select>
                    </div>
                 </div>
            }
            {role === "Parent" &&
                <div>
                    <label htmlFor="Children">Add child</label>
                    <select id="Child" type="text" className="form-control">
                        <option>These students need to be fetched from the backend</option>
                        <option>Student1</option>
                        <option>Student2</option>
                    </select>
                </div>
            }

            <button type="submit" className="btn btn-primary" onClick={handleSubmit}>Add</button>
        </form>

    )
}
export default RegistrationForm;