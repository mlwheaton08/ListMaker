import mod from "./Home.module.css"

export function Home() {

    return (
        <div>
            <img
                id="home-splash-img"
                src="../../../public/homeSplash.jpg"
                alt="List Maker logo"
            />
            <div id="home-splash-overlay"></div>

            <div id="home-container">
                <h1 className={mod.log}>Make shopping easier.</h1>
                <button className="px-3 py-1">
                    Start a new grocery list
                </button>
            </div>
        </div>
    )
}