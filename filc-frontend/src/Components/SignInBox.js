const SignInBox = () => {
    return (
        <div>
            <h3>Sign In</h3>
            <div className="col-md-12">
                <form>
                    <div className="form-group">
                        <label htmlFor="Email">Email</label>
                        <input id="Email" className="form-control" />
                    </div>
                    <div className="form-group">
                        <label htmlFor="Password">Password</label>
                        <input id="Password" className="form-control" />
                    </div>
                    <div className="form-group">
                        <div className="checkbox">
                            <label htmlFor="RememberMe">Remember Me</label>
                            <input id="RememberMe" type="checkbox" />
                        </div>
                    </div>
                    <button type="submit" className="btn btn-primary">Login</button>
                </form>
            </div>
        </div>
    )
}

export default SignInBox