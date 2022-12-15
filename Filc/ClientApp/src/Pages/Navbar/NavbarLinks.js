import Nav from 'react-bootstrap/Nav';

const NavbarLinks = ({ role }) => {

    // eslint-disable-next-line default-case
    switch(role){
        case "Government":
            return (
                <>
                    <Nav.Link href="govadmin/schools">All Schools</Nav.Link>
                    <Nav.Link href="govadmin/schooladmins/1">School Administrator by ID</Nav.Link>
                    <Nav.Link href="govadmin/schools/1/admins">School Administrator by School</Nav.Link>
                    <Nav.Link href="allstudents">All Students</Nav.Link>
                    <Nav.Link href="allteachers">Teacher related page</Nav.Link>
                </>
            )
        case "SchoolAdmin":
            return(
                <>
                    <Nav.Link href="">Administrators</Nav.Link>
                    <Nav.Link href="allschooladmins">School administrators</Nav.Link>
                    <Nav.Link href="">Add new user</Nav.Link>
                    <Nav.Link href="allschooladmins">School related page</Nav.Link>
                    <Nav.Link href="allteachers">Teacher related page</Nav.Link>
                    <Nav.Link href="">Lessons/Timetable</Nav.Link>
                    <Nav.Link href="allstudents">Students/Marks</Nav.Link>
                </>
            )

        case "Teacher":
            return(
                <>
                    <Nav.Link href="teachers">Teachers</Nav.Link>
                    <Nav.Link href="schools">Schools</Nav.Link>
                    <Nav.Link href="lessons">Lessons</Nav.Link>
                    <Nav.Link href="allstudents">Students</Nav.Link>
                </>
            )

        case "Student":
            return(
                <>
                    <Nav.Link href="govadmin/schools">Schools</Nav.Link>
                    <Nav.Link href="teachers">Teachers</Nav.Link>
                    <Nav.Link href="schools">Schools</Nav.Link>
                    <Nav.Link href="lessons">Lessons</Nav.Link>
                    <Nav.Link href="marks">Marks</Nav.Link>
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
export default NavbarLinks;
