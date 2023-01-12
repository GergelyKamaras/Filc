import { NavItem } from 'react-bootstrap';
import Nav from 'react-bootstrap/Nav';
import { useNavigate } from 'react-router-dom'
import "../../Style/navbar.css"

const SideBarNav = ({ role }) => {

    const navigate = useNavigate()

    function navigateTo(e, url) {
        
        navigate(url);
    }
    // eslint-disable-next-line default-case
    switch(role){
        case "Government":
            return (
                <>
                <div className='registration'> 
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "schooladmin/register")}> User Registration </button>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "govadmin/addschool")}> Institutional registration </button>
                </div>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "/govadmin/schools")}> Educational institutions  </button>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "/govadmin/schooladmins")}> Institutional administrators </button>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "/govadmin/students")}> Student directory </button>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "/govadmin/teachers")}> Teacher directory </button>
                </>
            )
        case "SchoolAdmin":
            return(
                <>
                    <div className='registration'> 
                        <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "schooladmin/register")}> User Registration </button>
                        <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "schooladmin/subject")}> Subject Registration  </button>
                    </div>
                        <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "schooladmin/schools")}> Educational institutions  </button>
                        <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "schooladmin/students")}> Student directory </button>
                        <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "schooladmin/teachers")}> Teacher directory </button>
                    
                </>
            )

        case "Teacher":
            return(
                <>
                    
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "teacher/teachers")}> Teacher directory </button>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "teacher/students")}> Student directory </button>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "teacher/add-grade")}> Student Grading </button>
                    
            
                </>
            )

        case "Student":
            return(
                <>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "student/myschool")}> Schools related page </button>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "teachers")}> Teachers </button>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "schools")}> Schools </button>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "lessons")}> Lessons </button>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "marks")}> Marks </button>
                    
                    <button  className='navbar-direction-button profile' typeof='button' onClick={(e) => navigateTo(e, "profile")}> Show profile </button>
                </>
            )

        case "Parent":
            return(
                <>
                    <Nav.Link href="students">My child</Nav.Link>
                    <Nav.Link href="teachers">Teachers</Nav.Link>
                    <Nav.Link href="lessons">Lessons</Nav.Link>
                </>
            )
        
        
    }
}
export default SideBarNav;
