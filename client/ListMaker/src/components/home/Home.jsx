import styles from "./Home.module.css"

export function Home() {

    return <>
        <img
            src="../../../public/homeSplash.jpg"
            alt="List Maker logo"
            className={styles.backgroundImg}
        />
        <div className={styles.backgroundOverlay}></div>

        <div className={styles.main}>
            <h1 className="text-4xl">
                Make shopping easier.
            </h1>
            <button className="px-3 py-1">
                Start a new grocery list
            </button>
        </div>
    </>
}