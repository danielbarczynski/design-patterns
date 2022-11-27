// without Singleton Pattern
// import FancyLogger from "./fancyLogger.js";
// const logger = new FancyLogger();
import logger from "./fancyLogger.js";

export default function log() {
    logger.log('first source file')
    logger.logCount();
}