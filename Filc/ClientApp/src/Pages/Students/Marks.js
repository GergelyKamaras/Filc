import { Link } from 'react-router-dom';

const Marks = () => {
    return (
        <div>
            <h1>[BETA] Your grades</h1>
            <p>Hi! This is the grades page. It's still under development since we don't have data in our database to display.</p><br />
            <p>This is how it will look like in the future with live data:</p>

            <table>
                <thead>
                    <th>Subject</th>
                    <th>Grades</th>
                </thead>
                <tbody>
                    <tr>
                        <td>Math</td>
                        <td><Link to="marks/id">5</Link>, <Link to="marks/id">3</Link>, <Link to="marks/id">5</Link></td>
                    </tr>
                    <tr>
                        <td>Literature</td>
                        <td><Link to="marks/id">3</Link>, <Link to="marks/id">3</Link>, <Link to="marks/id">1</Link></td>
                    </tr>
                    <tr>
                        <td>P.E.</td>
                        <td><Link to="marks/id">5</Link>, <Link to="marks/id">5</Link>, <Link to="marks/id">5</Link></td>
                    </tr>
                </tbody>
            </table>
        </div>
    );
}

export default Marks;