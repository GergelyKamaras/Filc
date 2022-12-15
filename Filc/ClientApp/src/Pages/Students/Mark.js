const Mark = () => {
    return (
        <div>
            <h1>[BETA] Your grade</h1>
            <p>Hi! This is the grade page. It's still under development since we don't have data in our database to display.</p><br />
            <p>This is how it will look like in the future with live data:</p>

            <h3>&lt;Grade&gt;</h3>
            <ul>
                <li><strong>Subject: </strong> &lt;Subject&gt;</li>
                <li><strong>Teacher: </strong> &lt;Teacher&gt;</li>
                <li><strong>Date: </strong> &lt;Date&gt;</li>
            </ul>
            <p>Description:</p><br />
            <small>&lt;Description&gt;</small>
        </div>
    );
}

export default Mark;